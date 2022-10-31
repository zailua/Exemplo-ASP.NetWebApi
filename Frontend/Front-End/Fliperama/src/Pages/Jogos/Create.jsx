import React, { useState, useEffect } from 'react'
import { Link, useNavigate, useParams } from 'react-router-dom'
import Api from '../../Api/Api'

export default function Create() {
	const [nome, setNome] = useState('')
	const [valor, setValor] = useState('')
	const [gamegen, setGamegen] = useState('')
	const [img, setImg] = useState('')
	const [id, setId] = useState(0)
	const navigate = useNavigate()

	const criarOuEditarJogo = (e) => {
		e.preventDefault()

		const jogo = { id, nome, valor, gamegen, img }

		if (id) {
			Api.put('/jogos/' + id, jogo).then((response) => {
				navigate('/Jogos')
			})
		} else {
			Api.post('/jogos/', jogo).then((response) => {
				navigate('/Jogos')
			})
		}
	}

	useEffect(() => {
		function getJogoById() {
			if (id) {
				Api.get(`/jogos/${id}`)
					.then((response) => {
						setId(response.data.id)
						setNome(response.data.nome)
						setGamegen(response.data.gamegen)
						setValor(response.data.valor)
					})
					.catch((error) => {
						console.log(error)
					})
			}
		}
		getJogoById()
	}, [id])

	return (
		<div className="container py-3">
			<form>
				<fieldset>
					<legend>
						<h2 className="text-center">{id ? 'Editar' : 'Criar'}</h2>
					</legend>
					<div className="mb-3">
						<div className="align">
							<input
								type="number"
								id="Id"
								className="form-control s"
								placeholder="ID"
								value={id}
								onChange={(e) => setId(Number.parseInt(e.target.value))}
							/>
						</div>
					</div>
					<div className="mb-3">
						<div className="align">
							<input
								type="text"
								id="Nome"
								className="form-control s"
								placeholder="Nome"
								value={nome}
								onChange={(e) => setNome(e.target.value)}
							/>
						</div>
					</div>
					<div className="mb-3">
						<div className="align">
							<input
								type="text"
								id="Valor"
								className="form-control s"
								placeholder="Valor"
								value={valor}
								onChange={(e) => setValor(e.target.value)}
							/>
						</div>
					</div>
					<div className="mb-3">
						<div className="align">
							<input
								type="text"
								id="Gamegen"
								className="form-control s"
								placeholder="Gênero"
								value={gamegen}
								onChange={(e) => setGamegen(e.target.value)}
							/>
						</div>
					</div>
					<div className="mb-3">
						<div className="align">
							<input
								type="text"
								id="Img"
								className="form-control s"
								placeholder="Url da Imagem"
								value={img}
								onChange={(e) => setImg(e.target.value)}
							/>
						</div>
					</div>
          <div className="d-flex justify-content-center">
					<button
						type="submit"
						className="btn btn-primary"
						onClick={(e) => criarOuEditarJogo(e)}
					>
						Enviar
					</button>
					<Link
						to="/Destinos"
						className="btn btn-danger"
						style={{ marginLeft: '10px' }}
					>
						Cancelar
					</Link>
          </div>
				</fieldset>
			</form>
		</div>
	)
}
