help:   	## Show this help.
	@fgrep -h "##" $(MAKEFILE_LIST) | fgrep -v fgrep | sed -e 's/\\$$//' | sed -e 's/##//'

build:  	## Docker compose build local code
		docker compose -f compose.build.yml build
local-up: 	## Docker compose up local code
		docker compose -f compose.build.yml up
up:		## Docker compose up images in backgroud
		docker compose up -d
down:		## Docker compose down
		docker compose down

up-db:
		## Docker up local db
		mkdir -p db && \
		sudo chown -R 10001:10001 db && \
		docker compose -f compose.build.yml up db
