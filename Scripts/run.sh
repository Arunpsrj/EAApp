#!/usr/bin/env sh

set -e
set -x

project="e2etest"

cd "$(dirname "${0}")/.."

export COMPOSE_HTTP_TIMEOUT=200

docker compose -p "$project" build

docker compose -p "$project" up -d ea_api ea_webapp db selenium-hub node-docker
docker compose -p "$project" up --no-deps ea_test


exit_code=$(docker inspect ea_test -f '{{ .State.ExitCode }}')

if [ $exit_code -eg 0 ]; then
    exit $exit_code
else
    echo "Test failed"
fi
