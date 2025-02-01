Connect-AzureAD

$addDomainName = ((Get-AzureAdTenantDetail).VerifiedDomains)[0].Name

$passwordProfile = New-Object -TypeName Microsoft.Open.AzureAD.Model.PasswordProfile

$passwordProfile.Password = 'Password@Test123'

$passwordProfile.ForceChangePasswordNextLogin = $false

New-AzureADUser -AccountEnabled $true -DisplayName 'add_lab_user1' -PasswordProfile $passwordProfile -MailNickName 'add_lab_user1' -UserPrincipalName "add_lab_user@$addDomainName" 