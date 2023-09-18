$(() => {
    $("input").on('input', function () {
        ensureValidity()
    })

    function ensureValidity() {


        const firstName = $("#firstName").val()//.trim()
        const lastName = $("#lastName").val()//.trim()
        const age = $("#age").val()//.trim()


        const isValid = firstName && lastName && age && isValidNumber(age)
        console.log(!isValid)
        $(".btn-primary").prop("disabled", !isValid)

    }

    const isValidNumber = value => !Number.isNaN(Number(value));

    let numOfRows = 1
    $("#add-rows").on("click", function () {
        addRow()
        numOfRows++
    })

    function addRow() {
        $("#ppl-rows").append(`  
                        <div class="row person-row bg-light rounded-3 p-3" style="margin-bottom: 10px;">
                            <div class="col-md-4">
                                <input class="form-control" type="text" name="people[${numOfRows}].firstname" placeholder="First Name" id="firstName" />
                            </div>
                            <div class="col-md-4">
                                <input class="form-control" type="text" name="people[${numOfRows}].lastname" placeholder="Last Name" id="lastName" />
                            </div>
                            <div class="col-md-4">
                                <input class="form-control" type="text" name="people[${numOfRows}].age" placeholder="Age" id="age" />
                            </div>
                        </div> `)
    }
})

//<div id="ppl-rows">
