#!/usr/bin/env sh

set -e
set -x

project="e2etest"

cd "$(dirname "${0}")/.."

export COMPOSE_HTTP_TIMEOUT=200

docker compose -p "$project" build

docker compose -p "$project" up -d ea_api ea_webapp db selenium-hub firefox chrome
docker compose -p "$project" up --no-deps ea_test

container_name="${project}_${service}_1"

sleep 2

exit_code=$(docker inspect "$container_name" -f '{{ .State.ExitCode }}')

if [ "$exit_code" -eq 0 ]; then
    echo "Test passed"
    exit 0
else
    echo "Test failed with exit code $exit_code"
    exit "$exit_code"
fi