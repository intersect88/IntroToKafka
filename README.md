# IntroToKafka
Publish Subscribe with Kafka using Confluent's .NET Client

# Create Zookeeper container with Docker

`
docker run --net=kafka \
-d \
--name=zookeeper \
-e ZOOKEEPER_CLIENT_PORT=2181 \
-e ZOOKEEPER_SERVER_ID=1 \
confluentinc/cp-zookeeper:5.4.1
`

# Create Kafka container with Docker

`
docker run --net=kafka \
-d \
-p 9092:9092 \
--name=kafka \
-e KAFKA_ZOOKEEPER_CONNECT=zookeeper:2181 \
-e KAFKA_ADVERTISED_LISTENERS=PLAINTEXT://localhost:9092 \
-e KAFKA_OFFSETS_TOPIC_REPLICATION_FACTOR=1 \
confluentinc/cp-kafka:5.4.1
`
