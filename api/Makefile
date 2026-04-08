db-up:
	docker compose -f Infra/compose.yml up -d

run: db-up
	dotnet run --project MoneiroAPI
