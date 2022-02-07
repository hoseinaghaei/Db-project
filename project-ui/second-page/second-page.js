let sortDir = false;
let receivedData;

window.onload = () => {
    getGoods();
};

function loadTableData(receivedData) {
    let heads = [];
    const tableHead = document.getElementById('table-head');
    let headHtml = '<tr>';
    for (let key in receivedData[0]) {
        if (receivedData[0].hasOwnProperty(key)) {
            headHtml += `<th  onclick = sortColumn(\'${key}\')>${key}</th>`;
            heads.push(key);
        }
    }
    headHtml += `</tr>`;
    tableHead.innerHTML = headHtml;

    const tableBody = document.getElementById('table-body');
    let bodyHtml = '';

    for (let data in receivedData) {
        bodyHtml += `<tr>`;
        for (const i of heads) {
            bodyHtml += `<td>${receivedData[data][i]}</td>`;
        }
        bodyHtml += `</tr>`;
    }

    tableBody.innerHTML = bodyHtml;
}

function sortColumn(columnName) {
    sortDir = !sortDir;
    const dataType = typeof receivedData[0][columnName];

    switch (dataType) {
        case "number":
            sortNumericColumn(sortDir, columnName);
            break;
        case "string":
            sortStringColumn(sortDir, columnName);
            break;
    }

    loadTableData(receivedData);
}

function sortNumericColumn(sort, columnName) {
    receivedData = receivedData.sort((d1, d2) => {
        return sort ? d1[columnName] - d2[columnName] : d2[columnName] - d1[columnName];
    });
}

function sortStringColumn(sort, columnName) {
    receivedData = receivedData.sort((d1, d2) => {
        return sort ? d1[columnName].localeCompare(d2[columnName]) : d2[columnName].localeCompare(d1[columnName]);
    });
}

function getGoods() {
    const Http = new XMLHttpRequest();
    const url = 'https://localhost:7058/SendQueries/GetGoods';
    Http.open("GET", url);
    Http.send();

    Http.onreadystatechange = (e) => {
        receivedData = Http.responseText;
        receivedData = JSON.parse(receivedData);
        loadTableData(receivedData);
    }
}

function seeTopBuyers() {
    document.getElementById('button-section').style.transform = 'translateX(-337%)';
    document.getElementById('table-title').innerText = "Top Customer In Payment";

    let count = prompt("HOW MANY BUYERS?");
    const Http = new XMLHttpRequest();
    const url = `https://localhost:7058/SendQueries/GetTopBuyer?count=${count}`;
    Http.open("GET", url);
    Http.send();

    Http.onreadystatechange = (e) => {
        receivedData = Http.responseText;
        receivedData = JSON.parse(receivedData);
        loadTableData(receivedData);
    }
}

function seeAllBuys() {
    document.getElementById('button-section').style.transform = 'translateX(-225%)';
    document.getElementById('table-title').innerText = "All Buy Records";
    const Http = new XMLHttpRequest();
    const url = `https://localhost:7058/SendQueries/GetAllBuys`;
    Http.open("GET", url);
    Http.send();

    Http.onreadystatechange = (e) => {
        receivedData = Http.responseText;
        receivedData = JSON.parse(receivedData);
        loadTableData(receivedData);
    }

}

function getCustomer() {
    document.getElementById('button-section').style.transform = 'translateX(-250%)';
    document.getElementById('table-title').innerText = "The Customer Information";

    let id = prompt("WHO?");
    const Http = new XMLHttpRequest();
    const url = `https://localhost:7058/SendQueries/GetCustomer?id=${id}`;
    Http.open("GET", url);
    Http.send();

    Http.onreadystatechange = (e) => {
        let a = Http.responseText;
        a = JSON.parse(a);

        for (let key in a) {
            if (a.hasOwnProperty(key)) {
                console.log(key);
                if (key === 'status') {
                    document.getElementById('button-section').style.transform = 'translateX(-328%)';
                }
            }
        }
        receivedData = [];
        receivedData.push(a);
        loadTableData(receivedData);
    }
}

function AddCustomer(){
    let id = prompt("ID?");
    let firstName = prompt("FIRSTNAME?");
    let lastName = prompt("LASTNAME?");
    let username = prompt("USERNAME?");
    let password = prompt("PASSWORD?");
    let email = prompt("EMAIL?");
    let firstPhone = prompt("MAIN-PHONE?");

    let data = {ID : id, Firstname : firstName, Lastname : lastName,
                Username : username, Password : password, Email : email, FirstPhone : firstPhone};

    let http = new XMLHttpRequest();
    http.open("POST", "https://localhost:7058/InsertData/InsertCustomer", true);
    http.setRequestHeader('Content-Type', 'application/json');
    http.send(JSON.stringify(data));

    http.onreadystatechange = (e) => {
        if (http.readyState && http.status === 200) {
            alert("Customer Inserted");
        }
    }
}

function AddBuyRecord(){
    let goodsId = prompt("GoodsID?");
    let AccountID = prompt("AccountID?");
    let qty = prompt("QTY?");
    let sheba = prompt("SHEBA?");
    let dop = prompt("DIGITAL_OR_PHYSICAL?");
    let score = prompt("SCORE?");

    let data = {GoodsId : goodsId, AccountId : AccountID, Qty : qty,
        Dop : dop, Score : score, Sheba : sheba};

    let http = new XMLHttpRequest();
    http.open("POST", "https://localhost:7058/InsertData/InsertBuyRecord", true);
    http.setRequestHeader('Content-Type', 'application/json');
    http.send(JSON.stringify(data));

    http.onreadystatechange = (e) => {
            alert("Buy Record Inserted");
    }
}