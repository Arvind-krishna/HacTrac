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

    # Copy SysmonConfigFolder to remote machine
    copy $SysmonConfigFolder V:\
    if($LASTEXITCODE)
    {
        Write-Host "Failed to copy $SysmonConfigFolder to v:\"
        goto UnmapAndContinue
    }

    Write-Host " All success ? "

} else {
    Write-Host "$ComputerName is not reachable. Unable to continue..."
    return
}
