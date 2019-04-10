param(
    [string] $ComputerName,
    [string] $UserName = $null,
    [string] $Pwd = $null,
    [string] $SysmonConfigFolder = ((Split-Path $script:MyInvocation.MyCommand.Path) + "\Sysmon")
)

#--  test network connectivity to the machine
Write-Host "Testing network connectivity to $ComputerName"
if( Test-Connection -ComputerName $ComputerName -Count 1 -ErrorAction SilentlyContinue) 
{   
    #--  test is config file exists
    if(Test-Path $SysmonConfigFolder)
    {
       Write-Host  "Could not locate Sysmon config folder : $SysmonConfigFolder "
       return
    } else {
       Write-Host  "Choosing Sysmon config file : $SysmonConfigFolder "
    }

    #--  test is user name and password are present
    $Creds = $null
    if( [string]::IsNullOrEmpty($UserName) -or [string]::IsNullOrEmpty($Pwd) )
    {
        $Creds = Get-Credential -Message "Enter credentials to connect to $ComputerName "
    } else {
        $Pwd1 = $Pwd | ConvertTo-SecureString -asPlainText -Force
        $Creds = New-Object System.Management.Automation.PSCredential($UserName,$Pwd1)
    }

    #-- test if credential is valid to connect to remote machine
    $details = Invoke-WmiMethod -ComputerName $ComputerName -Class Win32_ComputerSystem -Credential $Creds -ErrorAction SilentlyContinue
    if($details -eq $null)
    {
        Write-Host  "Could not connect to $ComputerName with given credentials"
        return
    }

    #-- Map the remote machine's C:\ as V:\ on local machine
    $ShareMapCmd = "net use V: \\$ComputerName\C$ /user:$($Creds.UserName) $($Creds.GetNetworkCredential().Password)"
    Write-Host $ShareMapCmd
    & $ShareMapCmd
    if($LASTEXITCODE)
    {
        Write-Host "Failed to map drive from remote machine" $ADComp.ComputerNames " : $LASTEXITCODE"
        return
    }

    #-- If you reached here, then drive has been mapped.
    Write-Host "Drive has been mapped as V:\ "
    

    #-- Define a cleanup function to unmap the network drive
    Function UnmapAndContinue {
        net use V: /delete
        if($LASTEXITCODE)
        {
            Write-Host "Failed to unmap network drive"
            return
        }
    }

    # Copy SysmonConfigFolder to remote machine
    copy $SysmonConfigFolder V:\
    if($LASTEXITCODE)
    {
        Write-Host "Failed to copy $SysmonConfigFolder to v:\"
        UnmapAndContinue()
        return
    }

    Write-Host " All success ? "

    #-- Enable auditing : Account Management success
    try{
        Write-Host "Attempting to execute: Auditpol /set /category:`"Account Management`" /success:enable"
        $proc = Invoke-WmiMethod -ComputerName $ComputerName -Class Win32_Process -Name Create -ArgumentList "Auditpol /set /category:`"Account Management`" /success:enable" -Credential $Creds
        Write-Host "Created Process on " $ComputerName " with process id:" $proc.ProcessId 
    }
    catch {
        Write-Host "Exception when invoking Win32_Process.Create."
        Write-Host $_.Exception.GetType().FullName, $_.Exception.Message
    }

    #-- Enable auditing : Account Management failure
    try{
        Write-Host "Attempting to execute: Auditpol /set /category:`"Account Management`" /failure:enable"
        $proc = Invoke-WmiMethod -ComputerName $ComputerName -Class Win32_Process -Name Create -ArgumentList "Auditpol /set /category:`"Account Management`" /failure:enable" -Credential $Creds
        Write-Host "Created Process on " $ComputerName " with process id:" $proc.ProcessId 
    }
    catch {
        Write-Host "Exception when invoking Win32_Process.Create."
        Write-Host $_.Exception.GetType().FullName, $_.Exception.Message
    }

    #-- enable other auditing as required.. you get the idea
    # see auditpol.exe's help for more details


    #-- Need to find the proper sysmon path and command and call it here
    <#-- Enable auditing : Account Management failure
    try{
        Write-Host "Attempting to execute: C:\sysmon.exe"
        $proc = Invoke-WmiMethod -ComputerName $ComputerName -Class Win32_Process -Name Create -ArgumentList "Auditpol /set /category:`"Account Management`" /failure:enable" -Credential $Creds
        Write-Host "Created Process on " $ComputerName " with process id:" $proc.ProcessId 
    }
    catch {
        Write-Host "Exception when invoking Win32_Process.Create."
        Write-Host $_.Exception.GetType().FullName, $_.Exception.Message
    }#>

    UnmapAndContinue()
} else {
    Write-Host "$ComputerName is not reachable. Unable to continue..."
    return
}
