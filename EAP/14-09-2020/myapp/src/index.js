import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import * as serviceWorker from './serviceWorker';
import Main from './Main'
ReactDOM.render(
  <React.StrictMode>
    <Main>

    </Main>
  </React.StrictMode>,
  document.getElementById('root')
);
serviceWorker.unregister();
