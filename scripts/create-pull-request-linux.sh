#!/bin/sh

cd "../cli/hub-linux-arm64-2.11.2"

hub pull-request -m "Automation pipeline update"

cd "../../scripts"

exit $?