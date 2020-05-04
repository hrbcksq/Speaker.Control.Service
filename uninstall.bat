set serviceName="Speaker Control Service"

sc stop %serviceName%
timeout /t 5 /nobreak > NUL
sc delete %serviceName%