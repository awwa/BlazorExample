docker compose build
docker compose up -d
# set -x
until [ "$(docker inspect --format='{{.State.Health.Status}}' $(docker compose ps -q postgres))" = 'healthy' ]; do
  echo "wait for postgres up..."
  sleep 1s
done
docker compose exec -w /source webapp dotnet ef database update --project ./Server/HogeBlazor.Server.csproj
docker compose exec -w /source webapp dotnet test
