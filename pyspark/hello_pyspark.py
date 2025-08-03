from pyspark.sql import SparkSession
from pyspark.sql.functions import col

# Cria uma SparkSession
spark = SparkSession.builder \
    .appName("HelloPySpark") \
    .master("local[*]") \
    .getOrCreate()

# Cria um DataFrame simples
data = [("Alice", 29), ("Bob", 35), ("Carol", 42)]
columns = ["nome", "idade"]

df = spark.createDataFrame(data, columns)

df = df.withColumn("triplo_idade", col("idade") * 3)

# Mostra o conteúdo do DataFrame
df.show()

# Finaliza a sessão
spark.stop()
