# FTP-Distribuido
Implementación de FTP Distribuido para la clase de Sistemas Distribuidos de Ciencias de la Computación en la Universidad de La Habana

Idea: Todo funciona sobre DHT

Idea: Usar bits más significativos del hash para garantizar replicación

Idea: Todo archivo se divide en pedazos de tamaño fijo para distribuir mejor la carga entre nodos

Idea: La llave es la ruta del archivo. Ej: /documento/file1.pdf@!part0 es la ruta del primer pedazo del archivo file1.pdf que está en el directorio documento.

Idea: Administrar los directorios también como un archivo que contenga información de su contenido y administre los locks necesarios para la modificación y verifique estén completos.

Tareas posibles:
  -Guardar
  -Pedir
  -Modificar
  -Borrar

Lenguaje propuesto: C#
