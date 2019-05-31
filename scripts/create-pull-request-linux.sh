#!/bin/sh

ROOT_DIRECTORY=$(dirname $(dirname $(readlink -f "$0")))
HUB_PATH="$ROOT_DIRECTORY/cli/hub-linux-amd64-2.11.2"
echo $HUB_PATH
export PATH=$HUB_PATH:$PATH

hub version

# git config --global user.email "travis@travis-ci.org"
# git config --global user.name "Travis CI"

# git remote add origin-push https://${GITHUB_TOKEN}@github.com/sfdrogojan/swagger-codegen-playground.git > /dev/null 2>&1

git fetch

git_branch=`git symbolic-ref --short HEAD`
branch_name=${git_branch}
echo "Current branch name is: $branch_name"
git checkout dev2
git pull origin dev2


hub pull-request -m "Automation pipeline update"

exit $?