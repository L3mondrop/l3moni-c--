docker build -t l3monitest:test .

docker run -it -p:3000:3000 l3monitest:test
or you can
docker compose up

Go to localhost:3000/runcmd to run the CPP program
