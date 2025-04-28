import { useWorkers } from "./WorkerContext";

function Dashboard() {
  const { workers, startWorker, stopWorker } = useWorkers();

  return (
    <div className="overflow-x-auto">
      <table className="min-w-full bg-white shadow-md rounded-lg">
        <thead>
          <tr className="bg-gray-200 text-gray-700">
            <th className="py-3 px-6 text-left">Worker Name</th>
            <th className="py-3 px-6 text-left">Scope</th>
            <th className="py-3 px-6 text-left">Status</th>
            <th className="py-3 px-6 text-left">Actions</th>
            <th className="py-3 px-6 text-left">Last Error</th>
          </tr>
        </thead>
        <tbody>
          {workers.map((worker) => (
            <tr key={worker.name} className="border-b hover:bg-gray-100">
              <td className="py-3 px-6">{worker.name}</td>
              <td className="py-3 px-6">{worker.scope}</td>
              <td className="py-3 px-6">
                {worker.status === "Running" ? (
                  <span className="bg-green-200 text-green-800 py-1 px-3 rounded-full text-xs">Running</span>
                ) : worker.status === "Stopped" ? (
                  <span className="bg-yellow-200 text-yellow-800 py-1 px-3 rounded-full text-xs">Stopped</span>
                ) : (
                  <span className="bg-red-200 text-red-800 py-1 px-3 rounded-full text-xs">Error</span>
                )}
              </td>
              <td className="py-3 px-6 space-x-2">
                {worker.status !== "Running" && (
                  <button
                    onClick={() => startWorker(worker.name)}
                    className="bg-blue-500 hover:bg-blue-700 text-white py-1 px-3 rounded"
                  >
                    Start
                  </button>
                )}
                {worker.status === "Running" && (
                  <button
                    onClick={() => stopWorker(worker.name)}
                    className="bg-red-500 hover:bg-red-700 text-white py-1 px-3 rounded"
                  >
                    Stop
                  </button>
                )}
              </td>
              <td className="py-3 px-6">{worker.lastError || "-"}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default Dashboard;
