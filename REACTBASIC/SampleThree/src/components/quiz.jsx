import React, { useState } from "react";


function Quiz(){

    function selectOptions(option){
        const newUserAnswer = [...userAnswers]
        newUserAnswer[currentQuestion] = option;

        setUserAnswers(newUserAnswer);
    }

    function NextQuestion(){
        setCurrentQuestion(currentQuestion + 1);
    }
    
    function PreviousQuestion(){

        if(currentQuestion > 0){
            setCurrentQuestion(currentQuestion - 1);
        }
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

    const preAnswers = [null,null,null];

    const [userAnswers, setUserAnswers] = useState(preAnswers);

    const [currentQuestion, setCurrentQuestion] = useState(0);

    return (
    <div className="card">
        <h2>Questionaire</h2>
        <p className="question">{questionaires[currentQuestion].question}</p>
        
        {questionaires[0].options.map((option) =>
        <button key={option} className="primary-btn option" onClick={() => selectOptions(option)}>
            {""}
            {option}
            </button>
        )}

        {/* <p>Selected: {selectedOption}</p> */}

        <div className="card-footer">
            <button onClick={PreviousQuestion} disabled={currentQuestion === 0} className="btn-primary" >Previous</button>
            <button onClick={NextQuestion} disabled={currentQuestion === 2 }  className="btn-primary">Next</button>
        </div>

    </div>
    )
}

export default Quiz;