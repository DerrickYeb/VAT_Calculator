let data = {
    Amount : document.getElementById("amount"),
    Quantity : document.getElementById("quantity"),
    IsFlateRate : document.getElementById("isFlateRate"),
    IsStandardRate : document.getElementById("isStandardRate")
}

const url = "https://localhost:44361/api/calculate/value/added/tax"

const handleCalculation = () => {
    e.preventDefault();
    axios.post(url, data)
        .then(function (response) {
            console.log(response);
            document.getElementById("flateRate") = response.FlatRate;
            document.getElementById("standardRate") = response.StandardRate;
            document.getElementById("nhil") = response.Nhil;
            document.getElementById("getfund") = response.Getfund;
            document.getElementById("vat") = response.VAT;
            document.getElementById("totalVat") = response.TotalVat;
        }).catch((error) =>{
            console.log(error) 
            alert(error.Message)
        })
}