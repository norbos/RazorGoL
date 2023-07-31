const onCellClick = (event) => {
    let coordinates = event.target.id.split('-');
    let row = coordinates[0];
    let col = coordinates[1];

    const cellElement = document.getElementById(event.target.id);
    cellElement.className = 'cell alive-cell';

    const requestOptions = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json',
            'RequestVerificationToken': $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        body: JSON.stringify({ row: row, column: col }),
    };
    
    fetch('/', requestOptions)
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response;
        }).catch(error => {
            console.error('Error:', error);
        });
}