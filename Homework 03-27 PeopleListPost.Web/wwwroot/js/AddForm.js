$(() => {
    
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

