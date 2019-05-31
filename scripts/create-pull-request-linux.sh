#!/bin/sh

ROOT_DIRECTORY=$(dirname $(dirname $(readlink -f "$0")))
HUB_PATH="$ROOT_DIRECTORY/cli/hub-linux-amd64-2.11.2"
echo $HUB_PATH
export PATH=$HUB_PATH:$PATH

hub version

hub pull-request -m "Automation pipeline update"

exit $?