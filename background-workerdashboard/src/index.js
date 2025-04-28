import React from "react";
import ReactDOM from "react-dom/client";
import App from "./App";
import { WorkerProvider } from "./context/WorkerContext";
import "./index.css";

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <React.StrictMode>
    <WorkerProvider>
      <App />
    </WorkerProvider>
  </React.StrictMode>
);
