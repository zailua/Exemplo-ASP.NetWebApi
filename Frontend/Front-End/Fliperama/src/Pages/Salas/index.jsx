import React, { useState, useEffect } from 'react'
import { Link, useNavigate } from 'react-router-dom'
import Api from '../../Api/Api'
import './sala.css'

export default function Index() {
	const [salas, setSalas] = useState([])
	const [redirect, setRedirect] = useState(false)

	useEffect(() => {
		Api.get('/Salas')
			.then((response) => {
				setSalas(response.data)
				setRedirect(false)
			})
			.catch((error) => {
				console.log(error)
			})
	}, [redirect, setRedirect])

	function deleteSala(id) {
		Api.delete(`/salas/${id}`)
		setRedirect(true)
	}

	return (
		<>
			<div className="container p-3">
				<Link to="/Salas-Create" className="btn btn-sakura mb-2">
					Postar Sala
				</Link>
				<div className="table-responsive d-flex justify-content-center">
					<table className="table table-hover table-sm table-colors">
						<thead>
							<tr>
								<th>ID</th>
								<th>Nome</th>
								<th>Jogo</th>
							</tr>
						</thead>
						<tbody>
							{salas.map((sala) => (
								<tr className="tColor tr-hover" key={sala.id}>
									<td className="tColor ">{sala.id}</td>
									<td className="tColor ">{sala.nome}</td>
									<td className="tColor ">{sala.jogo.nome}</td>
									<td className="tColor d-flex justify-content-end">
										<Link
											to={`/Salas-Update/${sala.id}`}
											className="btn btn-info"
										>
											Editar
										</Link>
										<button
											className="btn btn-danger"
											onClick={() => deleteSala(sala.id)}
											style={{ marginLeft: '10px' }}
										>
											Deletar
										</button>
									</td>
								</tr>
							))}
						</tbody>
					</table>
				</div>
			</div>
		</>
	)
}
