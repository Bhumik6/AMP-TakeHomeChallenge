const BASE_URL = "http://localhost:5000";

export const fetchWorkersAPI = async () => {
  const response = await fetch(`${BASE_URL}/api/trigger/workers`);
  const data = await response.json();
  return data;
};

export const startWorkerAPI = async (name) => {
  await fetch(`${BASE_URL}/api/trigger/run-worker`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ name }),
  });
};

export const stopWorkerAPI = async (name) => {
  await fetch(`${BASE_URL}/api/trigger/stop-worker`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ name }),
  });
};
