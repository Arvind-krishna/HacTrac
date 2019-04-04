#hello 
Function Save-Cred 
{
    param(
        [string] $username, 
        [string] $pw, 
        [string] $service
    )

    if( ( [string]::IsNullOrEmpty($username) -or [string]::IsNullOrEmpty($pw) ) -or [string]::IsNullOrEmpty($service)  )
    {
        return $false
    }


    return $true
}


Function Push-Configuration
{
    param([string] $configfile)

    if(Test-Path $configfile){
        $current_config = Get-Content  $configfile | ConvertFrom-Csv
        foreach($line in $current_config) {
            write-host $line
        }
        return $true
    }
    return $false
}
