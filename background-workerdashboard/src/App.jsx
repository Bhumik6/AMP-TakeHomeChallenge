import { WorkerProvider } from "./WorkerContext";
import Dashboard from "./Dashboard";

function App() {
  return (
    <WorkerProvider>
      <Dashboard />
    </WorkerProvider>
  );
}

export default App;
