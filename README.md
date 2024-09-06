# ORGANIZADOR DE FAMILIAS

## Introducción

La aplicación es una herramienta para gestionar archivos basados en un archivo CSV o Excel. Permite seleccionar un archivo CSV o Excel, seleccionar un directorio de origen de archivos, y un directorio de destino. Basado en la información del archivo CSV o Excel, la aplicación copia los archivos del directorio de origen a las carpetas especificadas en el directorio de destino.

## Funcionalidad Principal
Seleccionar Archivo CSV/Excel: Permite al usuario seleccionar un archivo CSV o Excel que contiene la información sobre el origen y destino de los archivos.
Seleccionar Directorio de Origen: Permite al usuario seleccionar el directorio donde se encuentran los archivos a copiar.
Seleccionar Directorio de Destino: Permite al usuario seleccionar el directorio de destino donde se copiarán los archivos.
Ejecutar Operación: Procesa los archivos y los copia a las carpetas especificadas en el archivo CSV o Excel.
Barra de Progreso: Muestra el progreso de la operación de copia.

## Instalación

Requisitos del Sistema
- Sistema Operativo: Windows 7 o superior.
- .NET Framework: .NET Framework 4.8 o superior.

Proceso de Instalación
- Descargar el Instalador: Obtén el archivo .msi
- Ejecutar el Instalador
- Sigue las instrucciones del asistente de instalación.
- Elige la ubicación de instalación deseada y completa la instalación.

Ruta de Instalación Predeterminada:
La aplicación se instala por defecto en C:\Program Files (x86)\Cemosa\OrganizadorFamilias

## Interfaz de Usuario
- Textbox para Archivo CSV/Excel: Campo para mostrar la ruta del archivo seleccionado.
- Botón para Importar Archivo CSV/Excel: Abre un cuadro de diálogo para seleccionar el archivo CSV o Excel.
- Textbox para Directorio de Origen: Campo para mostrar la ruta del directorio de origen.
- Botón para Seleccionar Directorio de Origen: Abre un cuadro de diálogo para seleccionar el directorio de origen.
- Textbox para Directorio de Destino: Campo para mostrar la ruta del directorio de destino.
- Botón para Seleccionar Directorio de Destino: Abre un cuadro de diálogo para seleccionar el directorio de destino.
- Botón Ejecutar: Inicia el proceso de copia basado en el archivo CSV o Excel.
- Barra de Progreso: Muestra el progreso del proceso de copia.

## Solución de Problemas

Mensajes de Error Comunes
- "Índice fuera de los límites de la matriz":
- Verifica que el archivo CSV o Excel esté correctamente formateado y contenga las columnas esperadas.
- Asegúrate de que los nombres de los archivos en el directorio de origen coincidan con los nombres en el archivo CSV o Excel.
- "No se puede copiar el archivo a la carpeta de destino":
- Asegúrate de que las carpetas de destino existen en el directorio de destino.
- Verifica que el archivo CSV o Excel tenga las rutas correctas para las carpetas de destino.
- Errores de Ruta de Instalación:

## Registro de Errores
Archivo de Registro
- Los errores y advertencias durante el proceso de copia se registran en un archivo de log.
- La ubicación del archivo de log se puede configurar en el código fuente. Asegúrate de revisar el archivo para obtener detalles sobre cualquier error ocurrido.
Revisar el Log
- Abre el archivo de log para revisar los detalles de los errores y advertencias.
- El archivo de log se encuentra en la misma carpeta que la aplicación o en una ruta configurada en el código.










