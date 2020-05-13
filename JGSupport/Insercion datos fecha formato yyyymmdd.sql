	
	use JGSupport;
	             						
	INSERT INTO Personal VALUES ('Estudio', 'Cassagne', 'estudio@cassagne.com.ar', '1150009999', 'cass', '1', '1')
	INSERT INTO Personal VALUES ('Croda', 'Argentina', 'info@croda.com', '1160006789', 'croda', '1', '1')
	INSERT INTO Personal VALUES ('Organización', 'Veraz', 'veraz@ovsa.com.ar', '1130015000', 'veraz', '1', '1')
	INSERT INTO Personal VALUES ('Luzzara', 'SRL', 'administracion@luzzara.com.ar', '1170007890', 'luzzara', '1', '1')
	INSERT INTO Personal VALUES ('Central', 'de Restaurantes', 'cdr@gmail.com', '1144443210', 'cdr', '1', '1')
	INSERT INTO Personal VALUES ('Federico', 'Piccolo', 'fp@jgsupport.com.ar', '1155550002', 'fede', '1', '2')
	INSERT INTO Personal VALUES ('Marcelo', 'Aparicio', 'ma@jgsupport.com.ar', '1155550003', 'marce', '1', '2')
	INSERT INTO Personal VALUES ('Martín', 'Cardoso', 'mc@jgsupport.com.ar', '1155550004', 'tincho', '1', '2')
	INSERT INTO Personal VALUES ('Lucas', 'Nicoloso', 'ln@jgsupport.com.ar', '1155550005', 'lucas', '1', '2')
	INSERT INTO Personal VALUES ('Edgardo', 'López', 'el@jgsupport.com.ar', '1155550006', 'edgar', '1', '2')
	INSERT INTO Personal VALUES ('Daniela', 'Rodríguez', 'coordinacion@jgsupport.com.ar', '1134567890', '123456', '1', '3')
	INSERT INTO Personal VALUES ('Mariano', 'Ink', 'mink@jgsupport.com.ar', '1150908909', 'mink', '1', '3')
	INSERT INTO Personal VALUES ('Juan Martín', 'Alfano', 'juan.alfano@istea.com.ar', '1155779985', '1234', '1', '4')
	INSERT INTO Personal VALUES ('Gabriel', 'Callegari', 'gabriel.callegari@istea.com.ar', '1157543706', '5678', '1', '4')
	INSERT INTO Personal VALUES ('Lionel', 'Mesa', 'lmesa@yahoo.com.ar', '1166778899', 'mesa', '0', '2')
	INSERT INTO Personal VALUES ('Telecom', 'Argentina', 'soporte@telecom.com.ar', '1144440000', 'telecom', '0', '1')


	INSERT INTO Privilegio VALUES ('Cliente', '1')
	INSERT INTO Privilegio VALUES ('Tecnico', '2')
	INSERT INTO Privilegio VALUES ('Coordinador', '3')
	INSERT INTO Privilegio VALUES ('Administrador', '4')

	INSERT INTO Solicitud VALUES ( '2018-1-3','2018-1-3', '1', '5', 'Instalación de impresora', '2', '2', '3')
	INSERT INTO Solicitud VALUES ( '2018-2-14','2018-2-14', '2', '4', 'Backup de datos de usuario', '2', '3', '2')
	INSERT INTO Solicitud VALUES ( '2018-3-8','2018-3-18', '3', '2', 'Agregar puesto de red', '2', '1', '1')
	INSERT INTO Solicitud VALUES ( '2018-4-18','2018-4-18', '4', '3', 'Creación de máquina virtual', '2', '2', '1')
	INSERT INTO Solicitud VALUES ( '2018-5-10','2018-5-10', '5', '1', 'Modificación de direccionamiento de correo', '2', '2', '2')
	INSERT INTO Solicitud VALUES ( '2018-6-14','2018-6-14', '1', '1', 'Colocación de reloj biométrico', '2', '2', '3')
	INSERT INTO Solicitud VALUES ( '2018-1-10','2018-1-11', '2', '5', 'Reinstalación de sistema operativo', '2', '1', '1')
	INSERT INTO Solicitud VALUES ( '2018-2-20','2018-4-28', '3', '3', 'Migración de bases de datos', '2', '2', '1')
	INSERT INTO Solicitud VALUES ( '2018-3-30','2018-3-30', '4', '2', 'Agregado de memoria RAM', '2', '3', '2')
	INSERT INTO Solicitud VALUES ( '2018-4-2','2018-4-2', '5', '2', 'Cambio de contraseña de WiFi', '2', '3', '3')
	INSERT INTO Solicitud VALUES ( '2018-5-6','2018-5-15', '1', '2', 'No recibe correos', '2', '1', '2')
	INSERT INTO Solicitud VALUES ( '2018-6-11','2018-6-11', '2', '3', 'Usuario no puede navegar', '2', '1', '3')
	INSERT INTO Solicitud VALUES ( '2017-12-27','2017-12-27', '3', '5', 'Alerta de virus', '2', '1', '1')
	INSERT INTO Solicitud VALUES ( '2017-11-30','2017-12-14', '4', '4', 'Windows no inicia', '2', '2', '2')
	INSERT INTO Solicitud VALUES ( '2017-10-29','2017-11-8', '5', '2', 'Monitor se ve negro', '2', '1', '3')
	INSERT INTO Solicitud VALUES ( '2017-9-21','2017-12-30', '1', '3', 'Proyecto de virtualización', '2', '2', '1')
	INSERT INTO Solicitud VALUES ( '2017-8-18','2017-8-18', '2', '4', 'Computadora hace ruidos raros', '2', '3', '3')
	INSERT INTO Solicitud VALUES ( '2017-7-8','2017-7-8', '3', '3', 'Webcam no funciona con Skype', '2', '3', '2')
	INSERT INTO Solicitud VALUES ( '2017-6-1','2017-6-1', '4', '1', 'No se escuchan micrófono y auriculares', '2', '1', '3')
	INSERT INTO Solicitud VALUES ( '2017-5-3','2017-5-10', '5', '5', 'Cambio de CPUs', '2', '2', '2')	

	INSERT INTO Tarea VALUES ('1','5','1', 'Se instaló impresora HP M553.', '1', '2018-1-4', '09:00', '10:00')
	INSERT INTO Tarea VALUES ('2','4','1', 'Se hizo copia de seguridad de los datos del usuario', '2', '2018-2-15', '10:00', '11:00')
	INSERT INTO Tarea VALUES ('3','2','1', 'Se pasó nuevo cable de red', '3', '2018-3-9', '11:00', '12:00')
	INSERT INTO Tarea VALUES ('4','3','2', 'Se creó máquina virtual', '4', '2018-4-19', '13:00', '14:00')
	INSERT INTO Tarea VALUES ('5','1','1', 'Se configuró Microsoft Exchange tal como se solicitó', '5', '2018-5-11', '14:00', '15:00')
	INSERT INTO Tarea VALUES ('6','1','1', 'Se amuró reloj a la pared', '1', '2018-6-15', '15:00', '16:00')
	INSERT INTO Tarea VALUES ('7','5','1', 'Se instaló Windows 10', '2', '2018-1-11', '16:00', '17:00')
	INSERT INTO Tarea VALUES ('8','3','1', 'Se comenzó migración de DBs', '3', '2018-2-25', '17:00', '18:00')
	INSERT INTO Tarea VALUES ('9','2','1', 'Se colocaron placas de memoria RAM adicionales', '4', '2018-3-31', '08:00', '09:00')
	INSERT INTO Tarea VALUES ('10','2','1', 'Se modificó contraseña según indicado por el cliente', '5', '2018-4-3', '18:00', '19:00')
	INSERT INTO Tarea VALUES ('11','2','1', 'Se revisó configuración de Microsoft Exchange', '1', '2018-5-7', '09:00', '10:00')
	INSERT INTO Tarea VALUES ('12','3','2', 'Se modificaron los DNS y funcionó correctamente', '2', '2018-6-12', '10:00', '11:00')
	INSERT INTO Tarea VALUES ('13','5','1', 'Se escaneó el equipo con un antivirus de manera offline', '3', '2017-12-28', '11:00', '12:00')
	INSERT INTO Tarea VALUES ('14','4','1', 'Se dañó disco rígido. Se programa cambio y reinstalación.', '4', '2017-12-1', '13:00', '14:00')
	INSERT INTO Tarea VALUES ('15','2','1', 'Monitor quemado. Se debe reemplazar.', '5', '2017-10-30', '14:00', '15:00')
	INSERT INTO Tarea VALUES ('16','3','1', 'Charla informativa con el cliente sobre tareas a desarrollar.', '1', '2017-9-22', '15:00', '16:00')
	INSERT INTO Tarea VALUES ('17','4','1', 'El ruido provenía del ventilador de la fuente. Fue reemplazada.', '2', '2017-8-19', '16:00', '17:00')
	INSERT INTO Tarea VALUES ('18','3','1', 'Se reinstalaron drivers de la webcam y funcionó correctamente.', '3', '2017-7-10', '17:00', '18:00')
	INSERT INTO Tarea VALUES ('19','1','1', 'Se hicieron cambios en la configuración de la placa de sonido.', '4', '2017-6-2', '08:00', '09:00')
	INSERT INTO Tarea VALUES ('20','5','1', 'Se comenzó con el cambio de CPUs', '5', '2017-5-11', '18:00', '19:00')
	INSERT INTO Tarea VALUES ('3','2','1', 'Se patcheó puesto de red', '4', '2018-3-10', '11:00', '12:00')
	INSERT INTO Tarea VALUES ('4','3','1', 'Se instaló S.O. en VM', '4', '2018-4-20', '10:00', '11:00')
	INSERT INTO Tarea VALUES ('6','1','1', 'Se configuró reloj con el sistema de control horario', '2', '2018-6-16', '11:00', '12:00')
	INSERT INTO Tarea VALUES ('7','5','2', 'Se instaló Office y otros programas', '2', '2018-1-12', '13:00', '14:00')
	INSERT INTO Tarea VALUES ('8','3','2', 'Se continuó con la migración', '2', '2018-3-10', '14:00', '15:00')
	INSERT INTO Tarea VALUES ('8','3','1', 'Se finalizó migración y se actualizó SQL Server', '2', '2018-4-28', '15:00', '16:00')
	INSERT INTO Tarea VALUES ('11','2','1', 'Se habló con el área de soporte del proveedor de Internet', '2', '2018-5-10', '16:00', '17:00')
	INSERT INTO Tarea VALUES ('11','2','2', 'Se descubrió que el problema provenía de un error en los certificados', '2', '2018-5-15', '17:00', '18:00')
	INSERT INTO Tarea VALUES ('15','2','2', 'Se cotizó monitor nuevo', '2', '2017-11-2', '08:00', '09:00')
	INSERT INTO Tarea VALUES ('15','2','1', 'Se llevó y conectó monitor nuevo. Todo OK.', '2', '2017-11-8', '18:00', '19:00')
	INSERT INTO Tarea VALUES ('14','4','1', 'Se reemplaza disco rígido.', '2', '2017-12-3', '09:00', '10:00')
	INSERT INTO Tarea VALUES ('14','4','1', 'Se reinstaló S.O.', '2', '2017-12-4', '10:00', '11:00')
	INSERT INTO Tarea VALUES ('14','4','1', 'Se restauran archivos personales del usuario', '2', '2017-12-10', '11:00', '12:00')
	INSERT INTO Tarea VALUES ('20','5','1', 'Cambio de CPUs - Día 2', '5', '2017-5-4', '13:00', '14:00')
	INSERT INTO Tarea VALUES ('20','5','1', 'Cambio de CPUs - Día 3', '4', '2017-5-6', '14:00', '15:00')
	INSERT INTO Tarea VALUES ('20','5','1', 'Cambio de CPUs - Día 4', '5', '2017-5-8', '15:00', '16:00')
	INSERT INTO Tarea VALUES ('20','5','1', 'Cambio de CPUs - Día 5', '4', '2017-5-10', '16:00', '17:00')
	INSERT INTO Tarea VALUES ('16','3','1', 'Realización de planificación (documentos).', '2', '2017-9-30', '17:00', '18:00')
	INSERT INTO Tarea VALUES ('16','3','1', 'Virtualización - Día 1', '1', '2017-10-10', '08:00', '09:00')
	INSERT INTO Tarea VALUES ('16','3','2', 'Virtualización - Día 2', '2', '2017-10-12', '18:00', '19:00')
	INSERT INTO Tarea VALUES ('16','3','2', 'Virtualización - Día 3', '1', '2017-10-14', '09:00', '10:00')
	INSERT INTO Tarea VALUES ('16','3','1', 'Virtualización - Día 4', '2', '2017-10-20', '10:00', '11:00')
	INSERT INTO Tarea VALUES ('16','3','1', 'Pruebas de configuración', '2', '2017-10-30', '11:00', '12:00')
	INSERT INTO Tarea VALUES ('16','3','2', 'Pruebas de performance y ajustes', '2', '2017-11-10', '13:00', '14:00')
	INSERT INTO Tarea VALUES ('16','3','1', 'Puesta en producción y acompañamiento', '2', '2017-12-30', '14:00', '15:00')
	INSERT INTO Tarea VALUES ('8','3','1', 'Pruebas de performance', '3', '2018-4-10', '15:00', '16:00')
	INSERT INTO Tarea VALUES ('8','3','2', 'Pruebas de backup y restore', '3', '2018-4-20', '16:00', '17:00')
	INSERT INTO Tarea VALUES ('8','3','1', 'Realización de documentación', '2', '2018-4-28', '17:00', '18:00')
	INSERT INTO Tarea VALUES ('3','2','1', 'Se realizaron pruebas de conectividad y se emprolijó cableado.', '1', '2018-3-18', '08:00', '09:00')
	INSERT INTO Tarea VALUES ('7','5','1', 'Se continuó con la reinstalación de programas adicionales.', '1', '2018-1-11', '18:00', '19:00')


	select * from personal;
	select * from privilegio;
	select * from solicitud;
	select * from tarea;

	select id_personal, nombre from personal where id_privilegio = 1;


	SELECT id_solicitud, descripcion_tarea FROM Solicitud WHERE id_cliente = 1



	SELECT id_personal, Nombre FROM Personal WHERE id_privilegio = 1 ORDER BY Nombre