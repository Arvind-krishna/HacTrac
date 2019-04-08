$Global:g_CurrentDir = Split-Path $script:MyInvocation.MyCommand.Path
#import-module E:\VMLGIT\HacTrac\PSScripts\CredentialManager
Import-Module "$Global:g_CurrentDir\CredentialManager"


# Example usage
# Install-LocalCredentialConfiguration $Global:g_CurrentDir\users.csv
Function Install-LocalCredentialConfiguration
{
    param([string] $configfile)
   

    if(Test-Path $configfile){
        $current_config = Get-Content  $configfile | ConvertFrom-Csv
        foreach($line in $current_config) {
            if($line.service -match "termsrv")
            {
                write-host "New-StoredCredential -Target TERMSRV/$($line.server) -UserName $($line.username) "
                write-host "$Global:g_CurrentDir"
                New-StoredCredential -Target "TERMSRV/$($line.server)" -UserName $line.username -Password $line.password -Type DomainPassword -Persist LocalMachine
            }
            else {
                write-host "New-StoredCredential -Target $($line.server) -UserName $($line.username) "
                New-StoredCredential -Target $line.server -UserName $line.username -Password $line.password -Type DomainPassword -Persist LocalMachine
            }
        }
        return $true
    }
    return $false
}

# Example usage
# Remove-LocalCredentialConfiguration $Global:g_CurrentDir\users.csv
Function Remove-LocalCredentialConfiguration
{
    param([string] $configfile)

    if(Test-Path $configfile){
        $current_config = Get-Content  $configfile | ConvertFrom-Csv
        foreach($line in $current_config) {

         if($line.service -match "termsrv")
         { 
            Remove-StoredCredential -Target "TERMSRV/$($line.server)" -Type DomainPassword }
         else
         {
            Remove-StoredCredential -Target $line.server -Type DomainPassword }
        }
        return $true
    }
    return $false
}

Function Get-LocalCredentialConfiguration
{
    
         $p = Get-StoredCredential -AsCredentialObject 
         $p | ConvertTo-Csv | Out-File fields.csv

         
    
}



Function Install-DomainCredentialConfiguration {
    param([string] $configfile)

    if(Test-Path $configfile){
        $current_config = Get-Content  $configfile | ConvertFrom-Csv
        foreach($line in $current_config) {
            # Call function to create domain user here
            & net user $line.username $line.password /add /domain
        }
        return $true
    }
    return $false
}



Function Remove-DomainCredentialConfiguration {
    param([string] $configfile)

    if(Test-Path $configfile){
        $current_config = Get-Content  $configfile | ConvertFrom-Csv
        foreach($line in $current_config) {
            # Call function to create domain user here
            & net user $line.username /delete /domain
        }
        return $true
    }
    return $false
}
