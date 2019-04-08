$Global:g_CurrentDir = Split-Path $script:MyInvocation.MyCommand.Path
Import-Module "$Global:g_CurrentDir\DeceptionLib.psm1"

Remove-LocalCredentialConfiguration $Global:g_CurrentDir\users.csv
