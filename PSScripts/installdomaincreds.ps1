Import-Module "$Global:g_CurrentDir\DeceptionLib.psm1"

Install-DomainCredentialConfiguration $Global:g_CurrentDir\users.csv
