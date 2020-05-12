#Set-ExecutionPolicy -Scope CurrentUser Unrestricted
Get-ExecutionPolicy

Write-Host "Deploying Edge Runtime"

. {Invoke-WebRequest -useb https://aka.ms/iotedge-win} | Invoke-Expression; Deploy-IoTEdge

$ScopeId = Read-Host -Prompt 'ScopeId'
$X509IdentityCertificate = Read-Host -Prompt 'X509IdentityCertificate'
$X509IdentityPrivateKey = Read-Host -Prompt 'X509IdentityPrivateKey'

$ScopeId = '0ne000FE8B4'
$X509IdentityCertificate = 'C:\Archive\Certificate\iot-edge-device-identity-iotedgedevice.cert.pem'
$X509IdentityPrivateKey = 'C:\Archive\Certificate\iot-edge-device-identity-iotedgedevice.key.pem'
#C:\Archive\windows10-edge\publicKey.cer
#C:\Archive\windows10-edge\privateKey.pem

Write-Host "Initializing DPS Auto-provisioning"
#Initialize-IoTEdge -Dps -ScopeId $ScopeId -X509IdentityCertificate $X509IdentityCertificate -X509IdentityPrivateKey $X509IdentityPrivateKey

#$Console = $ScopeId, $X509IdentityCertificate, $X509IdentityPrivateKey -join " "
#Write-Host $Console
Read-Host "Press Enter to continue"