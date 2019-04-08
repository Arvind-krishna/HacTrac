$Global:g_CurrentDir = Split-Path $script:MyInvocation.MyCommand.Path
Import-Module "$Global:g_CurrentDir\cred.ps1"
Get-CredManCreds
