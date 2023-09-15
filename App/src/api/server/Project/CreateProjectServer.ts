import axios from 'axios'
import {serverApi} from "../../../constants/serverApi";


export async function СreateProjectServer(name?: string){
    await axios.post(`${serverApi}/project/create`, { name: name })
}