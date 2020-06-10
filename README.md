![ReMade](./Logo.png)


### A collection of popular games, recreated using the Unity Game Engine.

Most, if not all of the assets in the games are made from scratch.

The purpose of this repo is just to up my Game Dev skills. Nothing fancy.

#### Running the Games

The games are exported in WebGL format so they can be run in the browser, for cross platform support. However, the browser may not allow you to directly run the game from `index.html`. For this, a local server must host the game instead.

Playing the games is straightforward:
``` bash
git clone https://github.com/dkapur17/ReMade.git
cd ReMade/<Game You Want to Play>/WebGL_Export
```
Now you need to run a local server in the folder.
For `Python` users, run:
```bash
python -m http.server -p 8080
```
`Node.js` users need to install the `http-server` module the first time around, if they havent already:
```bash
npm install -g http-server
```
Then run:
```bash
http-server -p 8080
```

Then open up you favorite browser that supports WebGL rendering and head to `localhost:8080`. Enjoy the game!
