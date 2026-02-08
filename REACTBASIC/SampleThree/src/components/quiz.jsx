import React, { useState } from "react";


function Quiz(){

    // var selectedOption = "None";
    function selectOptions(option){
        // console.log(option);
        // selectedOption = option;
        setSelectOptions(option);
    }

    const questionaires = [

        {
            question: "What is the capital of France?",
            options: ["Berlin", "London", "Paris", "Rome"],
            answer: "Paris"
        },
        {
            question: "Which language is used for web apps",
            options: [".NET", "PHP", "Javascript", "HTML"],
            answer: "All"
        },
        {
            question: "What does JSX stand for?",
            options: [
                "Javascript XML",
                "Java Syntax eXtension",
                "Just a Simple eXample",
                "None of the above"
            ],
            answer: "Javascript XML"
        },

    ]

    const [selectedOption, setSelectOptions] = useState("None");

    return (
    <div className="card">
        <h2>Questionaire</h2>
        <p className="question">{questionaires[0].question}</p>
        
        {questionaires[0].options.map((option) =>
        <button key={option} className="primary-btn option" onClick={() => selectOptions(option)}>
            {""}
            {option}
            </button>
        )}

        <p>Selected: {selectedOption}</p>

        <div className="card-footer">
            <button className="btn-secondary">Previous</button>
            <button>Next</button>
        </div>

    </div>
    )
}

export default Quiz;