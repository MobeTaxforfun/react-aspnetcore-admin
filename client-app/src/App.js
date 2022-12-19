import { useEffect } from 'react';
import GetRouters from "./routers/GetRouters";
import './App.css';

function App() {
  useEffect(() => {
    document.body.classList.add('gray-bg');
  }, []);

  return (
    <GetRouters></GetRouters>
  );
}

export default App;
