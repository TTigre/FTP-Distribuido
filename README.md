# FTP-Distribuido
Implementación de FTP Distribuido para la clase de Sistemas Distribuidos de Ciencias de la Computación en la Universidad de La Habana

Para encontrar los nodos correspondientes a los archivos se usa sobre Chord(DHT)

Idea: Usar bits más significativos del hash para garantizar replicación

Idea: Todo archivo se divide en pedazos de tamaño fijo para distribuir mejor la carga entre nodos

Idea: La llave es la ruta del archivo. Ej: /documento/file1.pdf@!part0 es la ruta del primer pedazo del archivo file1.pdf que está en el directorio documento.

Idea: Garantizar nivel de replicación 2 mínimo

Administrar los directorios también como un archivo que contenga información de su contenido y administre los locks necesarios para la modificación y verifique estén completos.

Tareas posibles:
Chord Related:
  -Quien tiene este recurso(WHOIS)

Alto Nivel
  -Guardar
  -Leer
  -Borrar

Lenguaje usado: C#
