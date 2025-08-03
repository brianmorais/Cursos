from pyspark.sql import SparkSession
from pyspark.sql.functions import col

spark = SparkSession.builder \
    .appName("LeituraCSV") \
    .master("local[*]") \
    .getOrCreate()

# Leitura do CSV
df = spark.read \
    .option("header", "true") \
    .option("inferSchema", "true") \
    .csv("utils/pessoas.csv")

df = df.withColumn("idade_em_meses", col("idade") * 12).orderBy("nome")

# Exibe os dados
df.show()

# Exibe o schema inferido
df.printSchema()

# Exemplo de transformação: filtro
df.filter(df.idade > 30).show()

df.write \
    .option("header", "true") \
    .mode("overwrite") \
    .csv("output/pessoas_transformadas")

spark.stop()
