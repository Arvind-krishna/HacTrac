

[CmdletBinding()]
param (
	
	[Parameter( Mandatory=$false)]
	[string]$InputFileName = "name.txt",

    [Parameter( Mandatory=$false)]
    [int]$PasswordLength = 16,

    [Parameter( Mandatory=$false)]
    [string]$OU = "Attivo"

	)


#...................................
# Variables
#...................................

$myDir = Split-Path -Parent $MyInvocation.MyCommand.Path

# Top level OU created to hold the users and other objects
# and the list of sub-OUs to create under it
$CompanyOU = $OU
$SubOUs = @(
    "Users",
    "Computers",
    "Groups",
    "Resources",
    "Shared"
    )

#Country and city for the test users
$Country = "IN"
$City = "Bangalore"

#List of department names randomly chosen for each user
$Departments = @(
    "Administration",
    "Human Resources",
    "Legal",
    "Finance",
    "Engineering",
    "Sales",
    "Information Technology",
    "Service"
    )

# Password length and character set to use for random password generation
$PasswordLength = 16
$ascii=$NULL;For ($a=33;$a -le 126;$a++) {$ascii+=,[char][byte]$a }


#...................................
# Functions
#...................................

# Test whether an OU already exists
Function Test-OUPath()
{
    param([string]$path)
    
    $OUExists = [adsi]::Exists("LDAP://$path")
    
    return $OUExists
}

# Random password generator
Function Get-TempPassword() {

    Param(
        [int]$length = $PasswordLength,
        [string[]]$sourcedata
    )

    For ($loop=1; $loop -le $length; $loop++)
    {
        $TempPassword+=($sourcedata | Get-Random)
    }

    return $TempPassword
}

#...................................
# Script
#...................................

if (!(Test-Path $InputFileName))
{
    Write-Warning "The input file name you specified can't be found."
    EXIT
}


# Create the OU structure to hold the test users and other objects

$Forest = Get-ADForest
$Domain = Get-ADDomain

$OUPath = "OU=" + $CompanyOU + "," + $Domain.DistinguishedName

if (!(Test-OUPath $OUPath))
{
    Write-Host "Creating OU: $CompanyOU"

    try
    {
        New-ADOrganizationalUnit -Name $CompanyOU -Path $Domain.DistinguishedName -ErrorAction STOP
    }
    catch
    {
        Write-Warning $_.Exception.Message
    }
}
else
{
    Write-Host "OU $CompanyOU already exists"
}

foreach ($SubOU in $SubOUs)
{
    $OUPath = "OU=$SubOU,OU=$CompanyOU," + $Domain.DistinguishedName
    
    if (!(Test-OUPath $OUPath))
    {
        Write-Host "Creating OU: $SubOU"
        New-ADOrganizationalUnit -Name $SubOU -Path $("OU=" + $CompanyOU + "," + $Domain.DistinguishedName)
    }
    else
    {
        Write-Host "OU $SubOU already exists"
    }
}


# Create the user accounts from the list of names
$ListOfNames = @()
$UsersOU = "OU=Users,OU=$CompanyOU," + $Domain.DistinguishedName

$RawNames = @(Get-Content $InputFileName)

foreach ($RawName in $RawNames)
{

    $FirstName = ($RawName.Trim()).Split(" ")[0]
    $LastName = ($RawName.Trim()).Split(" ")[1]

    $Department = $Departments[(Get-Random -Minimum 0 -Maximum ($($Departments.Count) - 1))]

    $Props = [ordered]@{
        "FullName" = $FirstName + " " + $LastName;
        "AccountName" = $FirstName + "." + $LastName;
        "FirstName" = $FirstName;
        "LastName" = $LastName;
        "Department" = $Department
        }

    $User = New-Object PSObject -Property $Props

    $ListOfNames += $User

}


foreach ($Name in $ListOfNames)
{
    Write-Host "Creating User: $($Name.FullName)"

    $randompassword = Get-TempPassword -length $PasswordLength -sourcedata $ascii
    $officephone = "555-" + ("{0:D4}" -f (Get-Random -Min 0000 -Maximum 9999))

    try
    {
        New-ADUser -Name $Name.FullName `
               -GivenName $Name.FirstName `
               -Surname $Name.LastName `
               -SamAccountName $Name.AccountName `
               -UserPrincipalName "$($Name.FirstName).$($Name.LastName)@$($Forest.Name)" `
               -Department $Name.Department `
               -Path $UsersOU `
               -Enabled $true `
               -AccountPassword (ConvertTo-SecureString $randompassword -AsPlainText -Force) `
               -OfficePhone $officephone `
               -Country $country `
               -City $city `
              # -ErrorAction STOP
    }
    catch
    {
        Write-Warning $_.Exception.Message
    }
}

#...................................
# Finished
#...................................

Write-Host "Finished."
