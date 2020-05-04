set serviceName="Speaker Control Service"

sc create %serviceName% binPath= %~dp0Speaker.Control.Service.exe
sc failure %serviceName% actions= restart/60000/restart/60000/""/60000 reset= 86400
sc config %serviceName% start=auto
sc start %serviceName%
