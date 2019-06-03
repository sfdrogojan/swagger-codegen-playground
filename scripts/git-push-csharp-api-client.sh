#!/bin/sh

ROOT_DIRECTORY=$(dirname $(dirname $(readlink -f "$0")))

if [ $OSTYPE = "msys" ]; then # Windows
    HUB_PATH="$ROOT_DIRECTORY/cli/hub-windows-amd64-2.11.2"
else
    HUB_PATH="$ROOT_DIRECTORY/cli/hub-linux-arm64-2.11.2"
fi

echo $HUB_PATH
export PATH=$HUB_PATH:$PATH

# Change path to the root folder of the repo
pushd ..

release_note="Automation pipeline update"
git_branch="dev2"
branch_name=${git_branch}
git fetch
git checkout ${branch_name}

# Adds the files in the local repository and stages them for commit.
git add .

# Commits the tracked changes and prepares them to be pushed to a remote repository.
git commit -m "$release_note"

git pull origin $branch_name

# Pushes the changes in the local repository up to the remote repository
hub push origin

popd