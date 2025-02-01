```powershell
# Conecta ao Azure Active Directory
Connect-AzureAD

# Obtém o nome do domínio verificado associado ao tenant do Azure AD
$addDomainName = ((Get-AzureAdTenantDetail).VerifiedDomains)[0].Name

# Cria um perfil de senha para o novo usuário
$passwordProfile = New-Object -TypeName Microsoft.Open.AzureAD.Model.PasswordProfile

# Define a senha do novo usuário
$passwordProfile.Password = 'Password@Test123'

# Configura para que o usuário não precise alterar a senha no primeiro login
$passwordProfile.ForceChangePasswordNextLogin = $false

# Cria um novo usuário no Azure Active Directory
New-AzureADUser -AccountEnabled $true -DisplayName 'add_lab_user1' -PasswordProfile $passwordProfile -MailNickName 'add_lab_user1' -UserPrincipalName "add_lab_user@$addDomainName"
```
