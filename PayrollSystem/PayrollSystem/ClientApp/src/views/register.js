import React, { Component, useState } from 'react';

function Register(){
    const [page,setpage] = useState("0%");
    const [STT,setSTT] = useState("btn btn-danger");
    return(
        <>
        <h6>Progressing : </h6>
        <div className="progress">
            <div className="progress-bar bg-success" style={{width: page}}></div>
        </div>
        <div className="list-group list-group-flush">
                    <li className="list-group-item">
                    <button data-toggle="modal" data-target="#CompAddr" type="button" class={STT}>1.Company's Address</button>
                    </li>
                    <li className="list-group-item">
                    <button type="button" class={STT}>2.Add accountant</button>
                     </li>
                    <li className="list-group-item">
                    <button type="button" class={STT}>3.Add Employee</button>
                    </li>
                    <li className="list-group-item">
                    <button type="button" class={STT}>4.Add contactor</button>
                    </li>
                    <li className="list-group-item">
                    <button type="button" class={STT}>5.Federal tax info</button>
                    </li>
                    <li className="list-group-item">
                    <button type="button" class={STT}>6.State Tax info</button>
                     </li>
                     <li className="list-group-item">
                    <button type="button" class={STT}>7.Bank Account</button>
                     </li>
                     <li className="list-group-item">
                    <button type="button" class={STT}>8.Pay Schedule</button>
                     </li>
                     <li className="list-group-item">
                    <button type="button" class={STT}>9.Sign documents</button>
                     </li>
                     <li className="list-group-item">
                    <button type="button" class={STT}>10.Verify bank account</button>
                     </li>
                     <li className="list-group-item">
                    <button type="button" class={STT}>11.Workers's comp</button>
                     </li>
                     <li className="list-group-item">
                    <button type="button" class={STT}>12.Discover apps</button>
                     </li>
                     <li className="list-group-item">
                    <button type="button" class={STT}>13.Choose a plan</button>
                     </li>
                </div>

                {/*Modal*/}
                {/*Company Addresss*/}
                <div class="modal fade" id="CompAddr">
                    <div class="modal-dialog modal-xl">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h4 class="modal-title">Company's Address</h4>
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                            </div>
                            <div class="modal-body">
                                <h3>Add Company Location</h3>
                                <hr></hr>
                                <a>To automate your payroll filings, we need to have your company’s accurate addresses. Please take a minute and enter them below.</a><br></br>
                                <strong>Street :</strong>
                                

                            </div>
                        </div>
                    </div>
                </div>
                {/*End modal*/}
        </>
    );
};
export default Register