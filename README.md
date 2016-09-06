# GitExt.TicketsHistoryPlugin - plugin for https://gitextensions.github.io/.

## What is this for?

This plugin was built to help to analyse a scope of changes in between two revisions. It will perfectly work for projects and teams which use JIRA/REDMINE/GITHUB kind system for project management and have the rule to track a ticket number in the commits' messages.

![alt screenshot](https://ipfs.pics/ipfs/QmfH4W1N3YcddHt9xFRWXkvw9diSdk43fxB1crAiQKiu6E)

##How does it work? 

It simply gets a list of revisions between two commits using 'git rev-list #hash1..#hash2' command. Then it searches for a text that matches a specific pattern in the commits' messages and beautifies output.

