Upload note:
- Repository prepared locally in this folder.
- Created .gitignore and LICENSE.
- To push, authenticate with GitHub (VS Code sign-in, GitHub CLI `gh auth login`, or a personal access token).

If push fails due to auth, run:

  git remote add origin https://github.com/obito1224/PROJECT-2.git
  git push -u origin main

If remote rejects because branch name differs, try:
  git push -u origin HEAD:main
