import React, {useState} from "react";
import axios from 'axios'

interface CreateProjectProps{
    onCreate: () => void
}

export function CreateProject({ onCreate } : CreateProjectProps){
    const [value, setValue] = useState<string>()

    const submitHandler = async (event: React.FormEvent) => {
        event.preventDefault()
        await axios.post("http://localhost:5031/api/project/create", { name: value })
        onCreate()
    }

    const changeHandler = (event: React.ChangeEvent<HTMLInputElement>) => {
        setValue(event.target.value)
    }

    return (
      <form onSubmit={submitHandler}>
          Name <input
            type="text"
            className="border py-2 px-4 mb-2 w-full outline-0"
            value={value}
            onChange={changeHandler}
          />
          <button className="py-2 px-4 border bg-yellow-400 hover:text-white">Create</button>
      </form>
    );
}