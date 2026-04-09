db-up:
	docker compose -f Infra/compose.yml up -d

run: db-up
	dotnet run --project MoneiroAPI

migration:
	dotnet ef migrations add $(name) --project MoneiroRepository --startup-project MoneiroAPI

db-migrate:
	dotnet ef database update --project MoneiroRepository --startup-project MoneiroAPI
