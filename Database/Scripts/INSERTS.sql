INSERT INTO USUARIO (correo, clave, nombre, apellido, avatar, idDropbox) 
VALUES ('elbano28@gmail.com',
'e1223d9bbcd82236f9f09ae1f5578e3cbbd4e8f48954cead3003be60ac85629726dc04b1f875353459f97ba4a4283a1a6adb89d3524bb4816c7125964097106c',
'elbano','marquez',null,null);

insert into LIBRETA (nombreLibreta,fkidUsuario) 
values ('Libreta de elbano',(select idUsuario from usuario where correo = 'elbano28@gmail.com'));

insert into NOTA (contenido,titulo,fechaCreacion,fechaModificacion,fkidLibreta) 
values ('Esta es la primera nota de prueba','Primera nota',GETDATE(),null,
(select idLibreta from LIBRETA where nombreLibreta = 'Libreta de elbano'));

insert into NOTA (contenido,titulo,fechaCreacion,fechaModificacion,fkidLibreta) 
values ('Esta es la segunda nota de prueba','Segunda nota',GETDATE(),null,
(select idLibreta from LIBRETA where nombreLibreta = 'Libreta de elbano'));

insert into NOTA (contenido,titulo,fechaCreacion,fechaModificacion,fkidLibreta) 
values ('Esta es la tercera nota de prueba','Tercera nota',GETDATE(),null,
(select idLibreta from LIBRETA where nombreLibreta = 'Libreta de elbano'));

-------------------------------------------------------------------------------Adjunto

insert into ADJUNTO (urlArchivo, titulo) values ('urlTemporal1','documento de texto.xdoc');
insert into ADJUNTO (urlArchivo, titulo) values ('urlTemporal2','documento de hoja de calculo.xls');
insert into ADJUNTO (urlArchivo, titulo) values ('urlTemporal3','documento de audio.mp3');
insert into ADJUNTO (urlArchivo, titulo) values ('urlTemporal4','documento de video.mp4');

insert into ADJUNTO_NOTA (fkidAdjunto, fkidNota) 
values((select idAdjunto from ADJUNTO where titulo = 'documento de texto.xdoc'),
(select idNota from NOTA where titulo = 'Primera nota'));

insert into ADJUNTO_NOTA (fkidAdjunto, fkidNota) 
values((select idAdjunto from ADJUNTO where titulo = 'documento de hoja de calculo.xls'),
(select idNota from NOTA where titulo = 'Primera nota'));

insert into ADJUNTO_NOTA (fkidAdjunto, fkidNota) 
values((select idAdjunto from ADJUNTO where titulo = 'documento de audio.mp3'),
(select idNota from NOTA where titulo = 'Primera nota'));

insert into ADJUNTO_NOTA (fkidAdjunto, fkidNota) 
values((select idAdjunto from ADJUNTO where titulo = 'documento de video.mp4'),
(select idNota from NOTA where titulo = 'Primera nota'));

insert into ADJUNTO_NOTA (fkidAdjunto, fkidNota) 
values((select idAdjunto from ADJUNTO where titulo = 'documento de texto.xdoc'),
(select idNota from NOTA where titulo = 'Segunda nota'));

insert into ADJUNTO_NOTA (fkidAdjunto, fkidNota) 
values((select idAdjunto from ADJUNTO where titulo = 'documento de hoja de calculo.xls'),
(select idNota from NOTA where titulo = 'Segunda nota'));

insert into ADJUNTO_NOTA (fkidAdjunto, fkidNota) 
values((select idAdjunto from ADJUNTO where titulo = 'documento de audio.mp3'),
(select idNota from NOTA where titulo = 'Segunda nota'));

insert into ADJUNTO_NOTA (fkidAdjunto, fkidNota) 
values((select idAdjunto from ADJUNTO where titulo = 'documento de texto.xdoc'),
(select idNota from NOTA where titulo = 'Tercera nota'));

insert into ADJUNTO_NOTA (fkidAdjunto, fkidNota) 
values((select idAdjunto from ADJUNTO where titulo = 'documento de hoja de calculo.xls'),
(select idNota from NOTA where titulo = 'Tercera nota'));

insert into ADJUNTO_NOTA (fkidAdjunto, fkidNota) 
values((select idAdjunto from ADJUNTO where titulo = 'documento de video.mp4'),
(select idNota from NOTA where titulo = 'Tercera nota'));

-------------------------------------------------------------------------------Etiqueta

insert into ETIQUETA (nombre) values ('Etiqueta 1');
insert into ETIQUETA (nombre) values ('Etiqueta 2');
insert into ETIQUETA (nombre) values ('Etiqueta 3');
insert into ETIQUETA (nombre) values ('Etiqueta 4');
insert into ETIQUETA (nombre) values ('Etiqueta 5');

insert into ETIQUETA_NOTA (fkidetiqueta, fkidnota) values 
((select idEtiqueta from ETIQUETA where nombre ='Etiqueta 1'),
((select idNota from NOTA where titulo = 'Primera nota')));

insert into ETIQUETA_NOTA (fkidetiqueta, fkidnota) values 
((select idEtiqueta from ETIQUETA where nombre ='Etiqueta 2'),
((select idNota from NOTA where titulo = 'Primera nota')));

insert into ETIQUETA_NOTA (fkidetiqueta, fkidnota) values 
((select idEtiqueta from ETIQUETA where nombre ='Etiqueta 3'),
((select idNota from NOTA where titulo = 'Primera nota')));

insert into ETIQUETA_NOTA (fkidetiqueta, fkidnota) values 
((select idEtiqueta from ETIQUETA where nombre ='Etiqueta 4'),
((select idNota from NOTA where titulo = 'Primera nota')));

insert into ETIQUETA_NOTA (fkidetiqueta, fkidnota) values 
((select idEtiqueta from ETIQUETA where nombre ='Etiqueta 5'),
((select idNota from NOTA where titulo = 'Primera nota')));

insert into ETIQUETA_NOTA (fkidetiqueta, fkidnota) values 
((select idEtiqueta from ETIQUETA where nombre ='Etiqueta 2'),
((select idNota from NOTA where titulo = 'Segunda nota')));

insert into ETIQUETA_NOTA (fkidetiqueta, fkidnota) values 
((select idEtiqueta from ETIQUETA where nombre ='Etiqueta 3'),
((select idNota from NOTA where titulo = 'Segunda nota')));

insert into ETIQUETA_NOTA (fkidetiqueta, fkidnota) values 
((select idEtiqueta from ETIQUETA where nombre ='Etiqueta 4'),
((select idNota from NOTA where titulo = 'Segunda nota')));

insert into ETIQUETA_NOTA (fkidetiqueta, fkidnota) values 
((select idEtiqueta from ETIQUETA where nombre ='Etiqueta 1'),
((select idNota from NOTA where titulo = 'Tercera nota')));

insert into ETIQUETA_NOTA (fkidetiqueta, fkidnota) values 
((select idEtiqueta from ETIQUETA where nombre ='Etiqueta 4'),
((select idNota from NOTA where titulo = 'Tercera nota')));

insert into ETIQUETA_NOTA (fkidetiqueta, fkidnota) values 
((select idEtiqueta from ETIQUETA where nombre ='Etiqueta 5'),
((select idNota from NOTA where titulo = 'Tercera nota')));