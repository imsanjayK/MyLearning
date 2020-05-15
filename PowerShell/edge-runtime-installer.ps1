#New-Module -Name edgeRuntime -ScriptBlock {
    set-executionpolicy Unrestricted 
    Get-ExecutionPolicy
    Set-Variable EdgeServiceName -Value 'iotedge' -Option Constant
    Set-Variable EdgeInstallDirectory -Value "$ProgramFilesDirectory\iotedge" -Option Constant
    Set-Variable LegacyEdgeInstallDirectory -Value 'C:\ProgramData\iotedge' -Option Constant
    
    Set-Variable ReinstallMessage -Value 'To reinstall, first remove the existing installation.' -Option Constant
    Set-Variable OkMessage -Value 'To Contuniue process, press y|Y' -Option Constant
    Set-Variable CancelMessage -Value 'To Cancel process, press n|N' -Option Constant
    Set-Variable InstallMessage -Value 'To install, run "Deploy-IoTEdge" first.' -Option Constant

	# private methods

	function Test-EdgeAlreadyInstalled {
		return (Get-Service $EdgeServiceName -ErrorAction SilentlyContinue) -or
		    (Test-Path -Path "$EdgeInstallDirectory\iotedged.exe") -or
	        (Test-path -Path "$LegacyEdgeInstallDirectory\iotedged.exe")
	}

	function Write-HostGreen {
		Write-Host -ForegroundColor Green @args
	}

	function Write-HostRed {
		Write-Host -ForegroundColor Red @args
	}

	function Write-HostYellow {
		Write-Host -ForegroundColor Yellow @args
	}

	# ends
	
    if (Test-EdgeAlreadyInstalled) {     
        
        Write-HostRed ('IoT Edge is already installed. ')
        Write-Host ($ReinstallMessage)
        
        $options =Read-Host ($OkMessage +' '+$CancelMessage)
        do{
            if ( $options -eq 'y' -or $options -eq 'Y') {

                $result = . {Invoke-WebRequest -useb aka.ms/iotedge-win} | Invoke-Expression; Uninstall-IoTEdge -Force
                break
            } 
            elseif( $options -eq 'n' -or $options -eq 'N') {
                Write-HostYellow ('Existing...')
                exit
            }
            else{
               $options = Read-Host('Please enter correct option')
               continue
            }
        }while($true)
    }

    Write-Host ('Install Edge Runtime ?')
    $options =Read-Host ($OkMessage +' '+$CancelMessage)

    do{
        if ( $options -eq 'y' -or $options -eq 'Y'){
        
            Write-Host ('Use default Edge Runtime setting')
            $options =Read-Host ($OkMessage +' '+$CancelMessage)

            if ( $options -eq 'y' -or $options -eq 'Y') {

                Write-Host ('Initializing default setting...')
                $ScopeId = '0ne000FE8B4'
                $X509IdentityCertificate = 'C:\Archive\Certificate\iotedgedevice.cert.pem'
                $X509IdentityPrivateKey =  'C:\Archive\Certificate\iotedgedevice.key.pem'
            }
            elseif( $options -eq 'n' -or $options -eq 'N') {
                $ScopeId = Read-Host -Prompt 'ScopeId'
                $X509IdentityCertificate = Read-Host -Prompt 'X509IdentityCertificate'
                $X509IdentityPrivateKey = Read-Host -Prompt 'X509IdentityPrivateKey'
            }

            Write-HostGreen ("Installating...")
            . {Invoke-WebRequest -useb https://aka.ms/iotedge-win} | Invoke-Expression; `
            Install-IoTEdge -Dps -ScopeId $ScopeId -X509IdentityCertificate $X509IdentityCertificate -X509IdentityPrivateKey $X509IdentityPrivateKey
            break
        }
        elseif( $options -eq 'n' -or $options -eq 'N') {
            Write-HostYellow ('Existing...')
            exit
        }
        else{
            $options = Read-Host ('Please enter correct option')
        }
    }while($true)

