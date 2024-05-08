import { useEffect, useState } from 'react';
import 'bootstrap/dist/css/bootstrap.css';
import Table from 'react-bootstrap/Table';
import Spinner from 'react-bootstrap/Spinner'
import '../App.css';


function Alerts() {
    const [alerts, setAlertData] = useState();
    useEffect(() => {
       
            getAlertsData();
       
    }, []);

    const contents = alerts === undefined
        ? <p><em><div style={{ display: 'block', width: 700, padding: 30 }}>
            <h4>Alert Data is Loading...</h4>
            <Spinner animation="border" variant="primary" /> <br /></div> </em></p>
        : <Table stripped bordered hover size="sm">
            <thead>
                <tr>
                    <th>AlertName</th>
                    <th>AlertType</th>
                    <th>RiskScore</th>
                    <th>AlertTriggeredOn</th>
                </tr>
            </thead>
            <tbody>
                {alerts.map(alert =>
                    <tr key={alert.AlertName}>
                        <td>{alert.AlertName }</td>
                        <td>{alert.AlertType}</td>
                        {alert.RiskScore > 80 ?
                            <td className="alert alert-danger">{alert.RiskScore}</td>
                            : <td className="alert alert-warning">{alert.RiskScore}</td>}
                        <td>{alert.AlertTriggeredOn.slice(0, 10)}</td>
                        
                    </tr>
                )}
            </tbody>
        </Table>;

    return (
        <div>
            <h1 id="tabelLabel">Alerts List</h1>
            <p>The alert Triggered.</p>
            {contents}
        </div>
    );

    async function getAlertsData() {
        const response = await fetch('alerts')
            .then(r => r.json()).then(res => {

                if (res) {
                    setAlertData(res);
                    
                }
            });            
        
        
        
    }
}

export default Alerts;