import { createContext, useContext, useEffect, useState } from "react";
import { fetchWorkersAPI, startWorkerAPI, stopWorkerAPI } from "./api";

const WorkerContext = createContext();

export function WorkerProvider({ children }) {
  const [workers, setWorkers] = useState([]);

  useEffect(() => {
    fetchWorkers();
  }, []);

  const fetchWorkers = async () => {
    const data = await fetchWorkersAPI();
    setWorkers(data);
  };

  const startWorker = async (name) => {
    await startWorkerAPI(name);
    fetchWorkers();
  };

  const stopWorker = async (name) => {
    await stopWorkerAPI(name);
    fetchWorkers();
  };

  return (
    <WorkerContext.Provider value={{ workers, startWorker, stopWorker }}>
      {children}
    </WorkerContext.Provider>
  );
}

export const useWorkers = () => useContext(WorkerContext);

