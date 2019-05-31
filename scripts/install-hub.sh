#!/bin/sh
# Install binary and documentation
wget https://github.com/github/hub/releases/download/v2.11.2/hub-linux-arm64-2.11.2.tgz
tar zvxvf hub-linux-arm64-2.11.2.tgz
sudo ./hub-linux-arm64-2.11.2/install

# Setup autocomplete for bash:
mkdir -p ~/.bash/completions
mv ./hub-linux-arm64-2.11.2/etc/hub.bash_completion.sh ~/.bash/completions/_hub
echo "if [ -f ~/.bash/completions/_hub ]; then" >> ~/.bashrc
echo "    . ~/.bash/completions/_hub" >> ~/.bashrc
echo "fi" >> ~/.bashrc

# add alias
echo "eval "$(hub alias -s)"" >> ~/.bashrc

# Cleanup
rm -rf hub-linux-arm64-2.11.2

hub version