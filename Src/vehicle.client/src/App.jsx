import { useEffect, useState } from 'react';
import './App.css';
import Navbar from './Navbar';

function App() {
    const [vehicles, setvehicles] = useState();

    useEffect(() => {
        populateVehiclesData();
    }, []);

    const contents = vehicles === undefined
        ? <p><em>Loading... Please refresh once the ASP.NET backend has started. See <a href="https://aka.ms/jspsintegrationreact">https://aka.ms/jspsintegrationreact</a> for more details.</em></p>
        : <table className="input-table" aria-labelledby="tableLabel">
            <thead>
                <tr>
                    <th>Id</th>
                    <th>Vehicle Id</th>
                    <th>Registration Number</th>
                    <th>Connection Status</th>
                    <th>Last Updated Date</th>
                </tr>
            </thead>
            <tbody>
                {vehicles.map(vehicle =>
                    <tr key={vehicle.id}>
                        <td>{vehicle.id}</td>
                        <td>{vehicle.vehicleId}</td>
                        <td>{vehicle.registrationNumber}</td>
                        <td>{vehicle.connectionStatus == false ? 'Inactive' : 'Active'}</td>
                        <td>{vehicle.lastUpdatedDate}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <Navbar></Navbar>
            {contents}
        </div>
    );

    //const response1 = await fetch('vehicle/customer?customerId=1');

    async function populateVehiclesData() {
        const response = await fetch('vehicle');
        if (response.ok) {
            const data = await response.json();
            setvehicles(data);
        }
    }
}

export default App;